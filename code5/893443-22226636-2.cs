    using System.IO;
    using System.Text;
    StringWriter sql = new StringWriter();
    sql.WriteLine("Select col1, col2 , col3");
    sql.WriteLine("From yourtable ");
    sql.WriteLine("Where 1 =1 ");
    if ((Txt1.Text.Length > 0)) {
    sql.WriteLine(("and col1 Like \'%" 
               
     + (Txt1.Text + "%\'")));
    }
    if ((Txt2.Text.Length > 0)) {
    sql.WriteLine(("and col2 \'%" 
               
     + (Txt2.Text + "%\'")));
    }
    if ((Txt3.Text.Length > 0)) {
    sql.WriteLine(("and col3 Like \'%" 
    + (Txt3.Text + "%\'")));
    }
    if ((Txt4.Text.Length > 0)) {
    sql.WriteLine(("and col4 Like \'%" 
    + (Txt4.Text + "%\'")));
    }
