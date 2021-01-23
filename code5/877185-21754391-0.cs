    class TrainerViewModel
    {
        private Trainer _trainer;
        public string ShortDescription
        {
            get
            {
                return _trainer.Description.ToString().Substring(0, 100);
            }
        }
        public TrainerViewModel(Trainer trainer)
        {
            _trainer = trainer;
        }
    }
