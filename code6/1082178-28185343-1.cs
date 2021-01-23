    interface IDepartmentEntity
    {
        void GenerateOutput();
    }
    class Office : IDepartmentEntity
    {
        public void GenerateOutput() { /* department-specific logic here */ }
    }
    // etc.
