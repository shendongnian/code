                ObservableCollection<Model> mycollection;
                public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    var coll = (ObservableCollection<Model>)value;
                    mycollection = coll;
                    if (coll.Count == 1)
                    {
                        if (parameter.ToString() == "FName")
                            return coll[0].FirstName;
                        else if (parameter.ToString() == "SName")
                            return coll[0].SecondName;
                        else if (parameter.ToString() == "Comp")
                            return coll[0].Company;
                    }
                    else if(coll.Count >1)
                    {
                       // string name = coll[0].FirstName;
                        if (parameter.ToString() == "FName")
                        {
                            string name = coll[0].FirstName;
                            foreach (var c in coll)
                            {
                                if (c.FirstName != name)
                                    return null;
                                else continue;
                            }
                            return name;
                        }
                        if (parameter.ToString() == "SName")
                        {
                            string name = coll[0].SecondName;
                            foreach (var c in coll)
                            {
                                if (c.SecondName != name)
                                    return null;
                                else continue;
                            }
                            return name;
                        }
                        if (parameter.ToString() == "Comp")
                        {
                            string name = coll[0].Company;
                            foreach (var c in coll)
                            {
                                if (c.Company != name)
                                    return null;
                                else continue;
                            }
                            return name;
                        }
                    }
                    return null;
                }
        
                public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    
                    if (parameter.ToString() == "FName")
                    {
                        foreach (var c in mycollection)
                        {
                            c.FirstName = value.ToString();
                        }
                        return mycollection;
                    }
                    else
                    if (parameter.ToString() == "SName")
                    {
                        foreach (var c in mycollection)
                        {
                            c.SecondName = value.ToString();
                        }
                        return mycollection;
                    }
                    else
                    if (parameter.ToString() == "Comp")
                    {
                        foreach (var c in mycollection)
                        {
                            c.Company = value.ToString();
                        }
                        return mycollection;
                    }
                    return null;
                }
            }
    
       
