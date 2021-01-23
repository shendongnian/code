    bool Compare(string url1, string url2)
            {
                url1.Replace("http://", String.Empty);
                url2.Replace("http://", String.Empty);
    
                if (url1.ToLower().Contains(url2.ToLower()) || url2.ToLower().Contains(url1.ToLower()))
                    return true;
    
                return false;
            }
