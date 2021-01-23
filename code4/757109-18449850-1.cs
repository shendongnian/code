        public void FillThemAll()
        {
           //Initialize some Lists
            listofOgg = new List<Organisation>();
            listofPers = new List<Person>();
 
            Organisation o = new Organisation();
            o.OrggName = "Stackoverflow";
            listofOgg.Add(o);
            //Another one
            o.OrggName = "Internet"; // Yes I know, I don't have any Organisation name :-)
            listofOgg.Add(o);
            //Now let's handle some Person
            Person p  = new Person("Tash Nar", "0123456", "StackOverFlow");
            Person p2 = new Person("Lionnel", "0123456", "StackOverFlow");
            Person p3 = new Person("You and Me", "0123456", "Internet");
            //Add them
            listofPers.Add(p);  listofPers.Add(p2); listofPers.Add(p3);
     
            //Now assuming that we have our two displayed ListBox (listbox1 and listbox2)
            //listbox1 for all organisations and listbox2 for more details about organisations
            //Let's fill listbox1 with our data
            for(int i=0; i < listofOgg.Count; i++)
            {
                 listbox1.Items.Add(listofOgg[i].Name);
            }  
        }
