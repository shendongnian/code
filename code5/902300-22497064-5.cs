    private void Children_Save_Click(object sender, EventArgs e)
        {
            int result=0;
            ss = SepStat.Text.ToString().Trim();
            pg = PopGr.Text.ToString().Trim();
            Add = ChildAdd.Text.ToString().Trim();
             if(int.TryParse(ChildDOBYr.Text,out result))
             {
                yr=ChildDOBYr.Text;
             }
             else
             {
               yr=result;
             }
            createdid=SaveChilDetails(ss,pg,Add,yr);
    
        }                
     
