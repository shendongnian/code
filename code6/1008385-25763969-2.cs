        private IOptions mIOptions;
        private BindingSource mbsProgramOptions;
        public int mOptionsID { get; set; }
        void AttachOptionsInterface(IOptions pOptions)
        {
            mIOptions = pOptions;
            CreateDataBindings();
        }
        private void CreateDataBindings()
        {
            mbsProgramOptions= new BindingSource();
            mbsProgramOptions.DataSource = mIOptions.mProgramOptionsList; // Or what ever datatable you have made
            dgvProgramOptions.AutoGenerateColumns = false;
            dgvProgramOptions.DataSource = mbsProgramOptions; // this binds your DataGridView to the DataSource
        }
