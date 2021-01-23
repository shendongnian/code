      Contacts cons = new Contacts();
                           foreach(var c in con)
                        {
                            a.cnts.Add(new Contactss()
                            {
                                name=c.name,
                                number=c.phone
                        });
                    }
                    lstbxk.ItemsSource = a.cnts;
               
            
       
