    // you can implement this Vali class in any of your classes
    // which you need to check their validation
    // Vali class will loop throw the properties of any another  class 
    // which implement it. and check their validations
    // and has IsValid which return the state of validation 
    // return true if valid
    public abstract class Vali {
        public bool IsValid {
            get {
                PropertyInfo propInfo = GetType().GetProperty("Error");
                object itemValue = propInfo.GetValue(this , null);
                string iiiii = (string)itemValue;
                foreach (PropertyInfo prop in GetType().GetProperties()) {
                    if (!String.IsNullOrWhiteSpace(met(prop.Name))) {
                        //MessageBox.Show("تاكد من صحة البيانات");
                        return false;
                    }
                }
                return true;
            }
        }
        public abstract string met(string columnName);
    }
    // as example your class will be like this  
    public class Phone : Vali , IDataErrorInfo {
        /// <summary>
        /// Código de área.
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// Identificador de tipo de teléfono.
        /// </summary>
        public short? PhoneTypeID { get; set; }
        /// <summary>
        /// Número de teléfono.
        /// </summary>
        public long? PhoneNumber { get; set; }
        /// <summary>
        /// Número de interno.
        /// </summary>
        public string ExtensionNumber { get; set; }
        public string Error {
            get { return null; }
        }
        public string this[string columnName] {
            get {
                return met(columnName);
            }
        }
        public override string met(string columnName)
        {
            if (columnName == "AreaCode") {
                if (string.IsNullOrWhiteSpace(AreaCode))
                    Error = ErrorMessages.ErrorMessage(ErrorMessages.FieldIsRequired , PhoneNameDictionary.GetValue(columnName));
            }
            if (columnName == "PhoneTypeID") {
                if (!PhoneTypeID.HasValue)
                    Error = ErrorMessages.ErrorMessage(ErrorMessages.FieldIsRequired , PhoneNameDictionary.GetValue(columnName));
            }
            if (columnName == "PhoneNumber") {
                if (!PhoneNumber.HasValue)
                    Error = ErrorMessages.ErrorMessage(ErrorMessages.FieldIsRequired , PhoneNameDictionary.GetValue(columnName));
            }
            return Error;
        }
    }
     
    class sdfasfd
    {
        public sdfasfd()
        {
            // u can do this in ur code
            Phone p = new Phone();
            //assign properties here for p
            MessageBox.Show(p.IsValid.ToString());
        }
    }
