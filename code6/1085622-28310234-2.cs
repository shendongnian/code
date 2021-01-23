    public class EditEntityProcessor : IEditEntityProcessor
    {
        private readonly Container container;
        private readonly IWindowManager windowManager;
        public EditEntityProcessor(Container container, IWindowManager windowManager)
        {
            this.container = container;
            this.windowManager = windowManager;
        }
        public void EditEntity<TEntity>(TEntity entity) where TEntity : class
        {
            // Compose type
            var editEntityViewModelType = 
            typeof(IEntityEditorViewModel<>).MakeGenericType(entity.GetType());
            // Ask S.I. for the corresponding ViewModel, 
            // which is responsible for editing this type of entity
            var editEntityViewModel = (IEntityEditorViewModel<TEntity>)
                     this.container.GetInstance(editEntityViewModelType);
            // give the viewmodel the entity to be edited
            editEntityViewModel.EditThisEntity(entity);
            // Let caliburn find the view and show it to the user
            this.windowManager.ShowDialog(editEntityViewModel);
        }
    }
    public interface IEntityEditorViewModel<TEntity> where TEntity : class
    {
        void EditThisEntity(TEntity entity);
    }
    public class EditUserViewModel : IEntityEditorViewModel<User>
    {
        public EditUserViewModel(
            ICommandHandler<SaveUserCommand> saveUserCommandHandler,
            IQueryHandler<GetUserByIdQuery, User> loadUserQueryHandler)
        {
            this.saveUserCommandHandler = saveUserCommandHandler;
            this.loadUserQueryHandler = loadUserQueryHandler;
        }
        public void EditThisEntity(User entity)
        {
            // load a fresh copy from the database
            this.User = this.loadUserQueryHandler.Handle(new GetUserByIdQuery(entity.Id));
        }
        // Bind a button to this method
        public void EndEdit()
        {
            // Save the edited user to the database
            this.saveUserCommandHandler.Handle(new SaveUserCommand(this.User));
        }
        
        //Bind different controls (TextBoxes or something) to the properties of the user
        public User User { get; set; }
    }
