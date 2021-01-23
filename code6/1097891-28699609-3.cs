    private bool FilterStars(object item)
        {
            bool b = false;
            star a = item as star;
            if (a != null)
            {
                if (a.Name.Contains(searchBoxText))  //your filter logic here
                    {
                       b = true;
                    }
                }
            }
            return b;
        }
