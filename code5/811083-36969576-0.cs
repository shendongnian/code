     JArray array = JArray.Parse(jsonString);
     foreach (JObject obj in array.Children<JObject>())
     {
         foreach (JProperty singleProp in obj.Properties())
         {
             string name = singleProp.Name;
             string value = singleProp.Value.ToString();
             //Do something with name and value
             //System.Windows.MessageBox.Show("name is "+name+" and value is "+value);
          }
     }
