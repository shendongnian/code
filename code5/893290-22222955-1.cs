       public Class Person
    {
       string name {get;set};
       int age {get;set};
       string hairColor (get;set}
         ///....etc
    
    }
     Person p=new Person();
    
      private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
               
                 p.name = listBox1.SelectedValue.ToString();
            }
   
