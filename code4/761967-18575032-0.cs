           JObject obj = JObject.Parse(json);
           var suggestionsArr = obj["spellcheck"].Value<JArray>("suggestions");
           var strings = new List<string>();
           foreach (var suggestionElem in suggestionsArr)
           {
               var suggestionObj = suggestionElem as JObject;
               if (suggestionObj != null)
               {
                   var subArr = suggestionObj.Value<JArray>("suggestion");
                   strings.AddRange(subArr.Select(suggestion => suggestion.ToString()));
               }
           }
