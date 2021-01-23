    using System.Windows.Forms;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;
    [TypeConverter(typeof(FontConverter))]
    internal class FontSerializationHelper
    {
        public static Font Deserialize(string value)
        {
            object m = Regex.Match(value, "^(?<Font>[\\w ]+),(?<Size>(\\d+(\\.\\d+)?))(,(?<Style>(R|[BIU]{1,3})))?$", RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
            if (m.Success) 
            {
                if (m.Groups.Count < 4 || m.Groups(3).Value == "R") 
                {
                    return new Font(m.Groups("Font").Value, Single.Parse(m.Groups("Size").Value));
                } 
                else 
                {
                    object fs = m.Groups(3).Value.IndexOf("B") >= 0 ? FontStyle.Bold : FontStyle.Regular | m.Groups(3).Value.IndexOf("I") >= 0 ? FontStyle.Italic : FontStyle.Regular | m.Groups(3).Value.IndexOf("U") >= 0 ? FontStyle.Underline : FontStyle.Regular;
                    return new Font(m.Groups("Font").Value, Single.Parse(m.Groups("Size").Value), fs);
                }
            } 
            else 
            {
                throw new FormatException("Value is not properly formatted.");
            }
        }
        public static string Serialize(Font value)
        {
            string str;
            str = value.Name + "," + value.Size.ToString() + ",";
            if (value.Style == FontStyle.Regular) 
            {
                str += "R";
            } 
            else 
            {
                if (value.Bold) str += "B";
                if (value.Italic) str += "I";
                if (value.Underline) str += "U";
            }
            
            return str;
        }
    }
