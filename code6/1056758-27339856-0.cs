      // create sample dictionary object: country list in North America
                Dictionary<string,> dictCountries = new Dictionary<string,>();
                dictCountries.Add("US", "United States of America");
                dictCountries.Add("CA", "Canada");
                dictCountries.Add("MX", "Mexico");
     
                // Method 1a: Data Binding DropDownList  `ddl2DictionaryDataBind` to Dictionary using DataSource and DataBind()
                ddl2DictionaryDataBind.DataSource = dictCountries;
                ddl2DictionaryDataBind.DataTextField = "Value";
                ddl2DictionaryDataBind.DataValueField = "Key";
                ddl2DictionaryDataBind.DataBind();
                ddl2DictionaryDataBind.ToolTip = "Data Bind to Dictionary using Value/Key";
                
                // Method 1b. Data Binding DropDownList `ddl2DictionaryBindValues` to Dictionary (either Keys or Values)
                // using DataSource property of the DropDownList object. This method will
                // render the <select> HTML element with option values and inner HTML
                // both corresponding to Dictionary Values (it could be bound to Keys instead)
                // note: this method requires System.Linq reference
                ddl2DictionaryBindValues.DataSource = dictCountries.Values.ToArray();
                ddl2DictionaryBindValues.DataBind();
                ddl2DictionaryBindValues.ToolTip = "Data Bind to Dictionary using only Values";
                
                // Method 1c. Data Binding DropDownList `ddl2DictionaryLoop` to Dictionary using iterations:
                // looping through the dictionary items and adding them to the DropDownList
                // this method will render the <select> HTML element with option values 
                // corresponding to Dictionary Keys and inner HTML corresponding to Values
                // note: if Dictionary contains data types other than String (for example, Dictionary<int,>)
                // then add the ToString() conversion to that data type
                ddl2DictionaryLoop.ToolTip = "Bind to Dictionary (Key/Values) using iteration";
                foreach (KeyValuePair<string,> _dictItem in dictCountries)
                {
                    ddl2DictionaryLoop.Items.Add(new ListItem(_dictItem.Value, _dictItem.Key));
                }
