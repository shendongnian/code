        [Route("Questionnaires")]
        public IEnumerable<Questionnaire> GetAllQuestionnaires()
        {
            NMQContext context = new NMQContext();
            return context.Questionnaires.AsEnumerable();
        }
