    public Question GetQuestion(int id)
    {
        get
        {
           return (Question)this.BaseGet((object)id);
        }
    }
