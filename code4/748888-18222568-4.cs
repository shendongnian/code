    public class ScriptMain : UserComponent
    {
    
        string toreplace = "[~!@#$%^&*()_+`{};':,./<>?]";
        string replacewith = "";
    
    
        public override void Input0_ProcessInputRow(Input0Buffer Row)
        {
            Regex reg = new Regex(toreplace);
    
            // Test for nulls otherwise Replace will blow up
            if (!Row.Na_IsNull)
            {
                Row.NaN = reg.Replace(Row.Na, replacewith);
            }
            else
            {
                Row.NaN_IsNull = true;
            }
    
            if (!Row.AgencyNames_IsNull)
            {
                Row.AgencyNamesCleaned = reg.Replace(Row.AgencyNames, replacewith);
            }
            else
            {
                Row.AgencyNamesCleaned_IsNull = true;
            }
        }
    
    }
