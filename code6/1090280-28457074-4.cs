    public ParameterCannotBeNullException extends MyException
    {
        private final int parameterNumber;
        public ParameterCannotBeNullException( int parameterNumber )
        {
            this.parameterNumber = parameterNumber;
        }
        public override String FormatMessage( String locale_specific_message )
        {
            return String.Format( locale_specific_message, parameterNumber );
        }
    }
