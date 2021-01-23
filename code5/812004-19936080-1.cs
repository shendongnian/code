           List<string> elements  = yourArray.ToList();
           if (null != elements && elements.Count > 50)
            {
                for (int i = 0; i < elements.Count; i += 50)
                {
                    Array result = elements.GetRange(i,50).ToArray();
                    // here you can pass the retrived list to your private method to do the necessary functionility. 
                    StringOperationForArray(result);
                }
            }
