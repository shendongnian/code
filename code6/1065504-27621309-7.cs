    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace FormToFormExample
    {
        public class EmployeeModel
        {
            #region Properties
            private Guid _employeeID;
            public Guid EmployeeID
            {
                get { return this._employeeID; }
                set { this._employeeID = value; }
            }
    
            private string _name;
            public string Name
            {
                get { return this._name; }
                set { this._name = value; }
            } 
            #endregion
    
            #region Constructors
            public EmployeeModel()
            {
                this._employeeID = Guid.NewGuid();
            }
    
            public EmployeeModel(string name)
                : this()
            {
                this._name = name;
            } 
            #endregion
        }
    }
