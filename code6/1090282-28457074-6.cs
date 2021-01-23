    public ParameterCannotBeNullException extends MyException
    {
        private final int parameterNumber;
        public ParameterCannotBeNullException( int parameterNumber )
        {
            this.parameterNumber = parameterNumber;
        }
        public override String FormatMessage( String localeSpecificMessage )
        {
            return String.Format( localeSpecificMessage, parameterNumber );
        }
    }
