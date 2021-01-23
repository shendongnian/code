       public ActionResult TriageScore(TriVM tri, FormCollection formCollection)
            {
                int i = 0;
                string[] value = new string[formCollection.Count];
                foreach (var key in formCollection.AllKeys)
                {
                    value[i] = formCollection[key];
                    i++;
                }
             }
