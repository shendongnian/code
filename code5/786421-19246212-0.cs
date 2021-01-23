    private void btnSave_Click(object sender, EventArgs e)
    {        
        db = new BetEntities();
        ScoreParam param = new ScoreParam();
        db.ScoreParams.Add(param);
        param.ScoreTypeID = _ScoresTypeID;
        param.Name = txtScoreName.Text;
        param.Code = txtScoreCode.Text.ToUpper();
        db.SaveChanges();
        this.Tag = db; 
        this.Close();
    }
