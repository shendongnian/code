    <div>
    @{
        try
        {
            //some code
            throw new SystemException();
            <div>yes</div>
        }
        catch 
        (
        #pragma warning disable 0168
            SystemException e
        #pragma warning restore 0168
        )
        {
            <div>error</div>
        }
    }
    </div>
