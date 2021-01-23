    public void DescribeCar()
    {
        Type t = this.GetType();
        //bad hack
        dynamic _this = Convert.ChangeType(this, t);
       	
      	this.ShowDetails(); //Prints "Standard transportation."
       	_this.ShowDetails(); //Prints "A roof that opens up."
    }
