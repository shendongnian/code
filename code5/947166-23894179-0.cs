    public override void WriteToStream(Type type, object value, Stream writeStream,
        System.Text.Encoding effectiveEncoding)
    {
        using (container.BeginExecutionContextScope())
        {
            var dataContext = _container.GetInstance<TestDataContext>(); 
            var result = dataContext.GetText();
            type = result.GetType();
            value = result;
            base.WriteToStream(type, value, writeStream, effectiveEncoding);
        }
    }
