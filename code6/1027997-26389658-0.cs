    std_table std = new std_table()
    {
        Name= nametxt.Text,
        Father_Name= fnametxt.Text,
        Class= classtxt.Text,
        Roll_Number= rolltxt.Text,
        Address=addresstxt.Text,
        Contact_Number=numtxt.Text,
        Date_Of_Birth=daybox.Text +" "+ monthbox.Text +" "+ yearbox.Text
    };
    if ( malebutton.Checked ) { 
        std.Gender = malebutton.Text;
    }
    if (femalebutton.Checked ) { 
        std.Gender = femalebutton.Text;
    }
