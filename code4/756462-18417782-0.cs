    public List<Operation> operations
    {
        get { return this._operations; }
        set 
        {
            this._operations = value;
            if (value != null)
            {
                this._operationsID.Clear();
                foreach (Operation oper in value)
                {
                    this._operationsID.Add(oper.ID);
                }
            }
            else
            {
                this._operationsID = null;
            }
        }
    }
