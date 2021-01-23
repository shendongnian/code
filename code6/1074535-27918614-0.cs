       BindingSource bs2 = new BindingSource();
            List<C_Exercice> l2 = new List<C_Exercice>();
            l2.Add(new C_Exercice("n", "", "", "", "", DateTime.Now, 1, 1, 5, 0, true));
            bs2.DataSource = l2;
    
    
            column2.DisplayMember = "Nom"; //works fine
            column2.DataSource = bs2;// My_Business.Get_Exercices_List("", "", "", 0, -1, true);
            column2.DisplayMember = "Nom"; //works fine
    
    
            BindingSource bs = new BindingSource();
            List<C_Exercice> l = new List<C_Exercice>();
            l.Add(new C_Exercice("n", "", "", "", "", DateTime.Now, 1, 1, 5, 0, true));
            bs.DataSource = l;
    
    
            column.DisplayMember = "Nom"; //works fine
            column.DataSource = bs;// My_Business.Get_Exercices_List("", "", "", 0, -1, true);
            column.DisplayMember = "Nom";  //causes the nullreference error
