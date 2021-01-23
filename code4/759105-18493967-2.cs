    public class Table_Archetype : DbObjectTableBase
    {
        #region Fields
        private System.String name = "ChangeMe";
        private System.Int32 fK_ToolField_ID_DataSource = 0;
        private System.String description__DEV = "";
        private System.Int32 fK_EnumArray_ID_DataExportType = 19;
        private System.Boolean isDeleted = false;
        #endregion
        public Table_Archetype() { }
        public Table_Archetype(System.Int32 inID) { base.id = inID; }
        public Table_Archetype(
            System.Int32 inID
            , System.String inName
            , System.Int32 inFK_ToolField_ID_DataSource
            , System.String inDescription__DEV
            , System.Int32 inFK_EnumArray_ID_DataExportType
            , System.Boolean inIsDeleted
        )
        {
            base.id = inID;
            this.name = inName;
            this.fK_ToolField_ID_DataSource = inFK_ToolField_ID_DataSource;
            this.description__DEV = inDescription__DEV;
            this.fK_EnumArray_ID_DataExportType = inFK_EnumArray_ID_DataExportType;
            this.isDeleted = inIsDeleted;
        }
        #region Properties
        public System.String Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.isDirty = true;
                }
            }
        }
        public System.Int32 FK_ToolField_ID_DataSource
        {
            get { return this.fK_ToolField_ID_DataSource; }
            set
            {
                if (this.fK_ToolField_ID_DataSource != value)
                {
                    this.fK_ToolField_ID_DataSource = value;
                    this.isDirty = true;
                }
            }
        }
        public System.String Description__DEV
        {
            get { return this.description__DEV; }
            set
            {
                if (this.description__DEV != value)
                {
                    this.description__DEV = value;
                    this.isDirty = true;
                }
            }
        }
        public System.Int32 FK_EnumArray_ID_DataExportType
        {
            get { return this.fK_EnumArray_ID_DataExportType; }
            set
            {
                if (this.fK_EnumArray_ID_DataExportType != value)
                {
                    this.fK_EnumArray_ID_DataExportType = value;
                    this.isDirty = true;
                }
            }
        }
        public System.Boolean IsDeleted
        {
            get { return this.isDeleted; }
            set
            {
                if (this.isDeleted != value)
                {
                    this.isDeleted = value;
                    this.isDirty = true;
                }
            }
        }
        #endregion
