    protected void FooPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
	    var notMapped = typeof(Foo).GetProperty(e.PropertyName).GetCustomAttributes(typeof(NotMappedAttribute), false);
		if (notMapped.Length == 0)
		{
			UnitOfWork.Value.GetRepository<Foo>().Update(MyFoo);
		}
    }
