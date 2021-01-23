        public override void Execute(DeleteApplicationCommand command)
        {
            Debug.WriteLine("DeleteApplicationCommand executed");
            var application = this.DbContext.Applications.FirstOrDefault(m => m.Id == command.CommandArg.Id);
            if (application == null)
            {
                throw new Exception(string.Format("Application with id {0} was not found", command.CommandArg.Id));
            }
            this.DbContext.Applications.Remove(application);
            this.DbContext.SaveChanges();
        }
