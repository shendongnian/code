    public ParameterCannotBeNullException extends MyException
    {
        private final int parameterNumber;
        public ParameterCannotBeNullException( int parameterNumber )
        {
            this.parameterNumber = parameterNumber;
        }
        protected override void FormatMessage( String locale_specific_message )
        {
            String.Format( locale_specific_message, parameterNumber );
        }
    }
