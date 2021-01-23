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
            if(path != string.Empty)
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
    }
    
    public class Program
    {
        public static void Main()
        {
            TotalAsset total = new TotalAsset(new BuildingAsset(new HistoricalBuildingAsset()));
    
            // Prints "TotalAsset.BuildingAsset.HistoricalBuildingAsset"
            Console.WriteLine(total.FullPath);
        }
    }
