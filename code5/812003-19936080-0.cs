           if (null != elements && elements.Count > 50)
            {
                for (int i = 0; i < elements.Count; i += 50)
                {
                    List<string> result = elements.GetRange(i,50);
                    // here you can pass the retrived list to your private method to do the necessary functionility. 
                    StringOperationForList(result);
                }
            }
