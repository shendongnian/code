    public class Dummy
    {
        private string _field;
        [Required]
        [StringLength(int.MaxValue, MinimumLength=6)]
        [DataType(DataType.Password)]
        public string Field
        {
            get
            {
                if (_field == null)
                {
                    throw new ArgumentNullException("Argh!");
                }
                return Utils.ByteArrayConverter.ByteArrayToString(
                    MD5CryptoServiceProvider.Create(_field).Hash); 
            }
            set
            {
                _field = value;
            }
        }
    }
