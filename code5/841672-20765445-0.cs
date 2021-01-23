    private void OnSubmitRatingHandler(...)
    {
        IDictionary<int, int> Ratings = new Dictionary<int,int>();
        for(int i = 0; GridViewDoctor.Rows.Count; i++)
        {
           Label lblDocId = GridViewDoctor.Rows[i].FindControl("lblDoctorId") as Label;
           sTmp = lblDocId.Text;
           DocId = Int32.Parse(sTmp);
    
           RadioButton rdr1 = GridViewDoctor.Rows[i].FindControl("RadioButton1") as RadioButton;
           ... same for rdr2/3/4/5
           if(rdr1.Checked) { Rating=1; } else if(rdr2.Checked) { Rating=2; } ...
           Ratings.Add(DocId, Rating}
        }
        return;
    }
