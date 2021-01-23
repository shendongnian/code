    using System;
    using System.Linq;
    using System.Reflection;
    
    public abstract class Field
    {
        public double Value
        {
            get;
            set;
        }
    
        public string Path
        {
            get;
            protected set;
        }
    
        public string FullPath
        {
            get
            {
                return BuildPath(this);
            }
        }
    
    
        /// <summary>
        /// Recursively-builds a dot-separated full path of associated fields
        /// </summary>
        /// <param name="field">Optional, it's a reference to current associated field </param>
        /// <param name="path">Optional, provided when this method enters to the first associated </param>
        /// <returns>The whole dot-separated full path of associations to Field</returns>
        private string BuildPath(Field field, string path = "")
        {
            // Top-level path won't start with dot
            if (path != string.Empty)
            {
                path += '.';
            }
    
            path += field.Path;
    
            // This will look for a property which is of type Field
            PropertyInfo fieldProperty = field.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                                    .SingleOrDefault(prop => prop.PropertyType.IsSubclassOf(typeof(Field)));
    
            // If current field has a property of type Field...
            if (fieldProperty != null)
            {
                // ...we'll get its value and we'll start a recursion to find the next Field.Path
                path = BuildPath((Field)fieldProperty.GetValue(field, null), path);
            }
    
            return path;
        }
    
        /// <summary>
        /// Recursively sets a value to an associated field property
        /// </summary>
        /// <param name="path">The whole path to the property</param>
        /// <param name="value">The value to set</param>
        /// <param name="associatedField">Optional, it's a reference to current associated field</param>
        public void SetByPath(string path, object value, Field associatedField = null)
        {
            if (string.IsNullOrEmpty(path.Trim()))
            {
                throw new ArgumentException("Path cannot be null or empty");
            }
    
            string[] pathParts = path.Split('.');
    
            if (associatedField == null)
            {
                associatedField = this;
            }
    
            // This will look for a property which is of type Field
            PropertyInfo property = associatedField.GetType().GetProperty(pathParts[0], BindingFlags.Public | BindingFlags.Instance);
    
            if (property == null)
            {
                throw new ArgumentException("A property in the path wasn't found", "path");
            }
    
            object propertyValue = property.GetValue(associatedField, null);
    
            // If property value isn't a Field, then it's the last part in the path 
            // and it's the property to set
            if (!propertyValue.GetType().IsSubclassOf(typeof(Field)))
            {
                property.SetValue(associatedField, value);
            }
            else
            {
                // ... otherwise, we navigate to the next associated field, removing the first
                // part in the path, so the next call will look for the next property...
                SetByPath(string.Join(".", pathParts.Skip(1)), value, (Field)propertyValue);
            }
        }
    }
    
    public sealed class TotalAsset : Field
    {
        public TotalAsset(BuildingAsset buildingAsset)
        {
            Path = "TotalAsset";
            BuildingAsset = buildingAsset;
        }
    
        public BuildingAsset BuildingAsset
        {
            get;
            private set;
        }
    }
    
    public sealed class BuildingAsset : Field
    {
        public HistoricalBuildingAsset HistoricalBuildingAsset
        {
            get;
            private set;
        }
    
        public BuildingAsset(HistoricalBuildingAsset historicalBuildingAsset)
        {
            Path = "BuildingAsset";
            this.HistoricalBuildingAsset = historicalBuildingAsset;
        }
    }
    
    public sealed class HistoricalBuildingAsset : Field
    {
        public HistoricalBuildingAsset()
        {
            Path = "HistoricalBuildingAsset";
        }
    
        public int Age
        {
            get;
            set;
        }
    }
    
    public class Program
    {
        public static void Main()
        {
            TotalAsset total = new TotalAsset(new BuildingAsset(new HistoricalBuildingAsset()));
    
            // Prints "TotalAsset.BuildingAsset.HistoricalBuildingAsset"
            Console.WriteLine(total.FullPath);
    
            total.SetByPath("BuildingAsset.HistoricalBuildingAsset.Age", 300);
    
            // Prints "300" as expected!
            Console.WriteLine(total.BuildingAsset.HistoricalBuildingAsset.Age);
    
            Console.Read();
        }
    }
