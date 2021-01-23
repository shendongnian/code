    namespace UWA.MenuFlyout.ViewModels
    {
        using System.Collections.ObjectModel;
        using System.Windows.Input;
        using UWA.MenuFlyout.Core;
        using UWA.MenuFlyout.Models;
    
        public class MainViewModel : BaseViewModel
        {
            private ICommand editTodo;
    
            private ICommand deleteTodo;
    
            public MainViewModel()
            {
                this.Todos = new ObservableCollection<TodoModel>
                {
                    new TodoModel { Id = 1, Action = "Buy Milk", IsDone = true },
                    new TodoModel { Id = 2, Action = "Buy Groceries", IsDone = false }
                };
            }
    
            public ObservableCollection<TodoModel> Todos { get; set; }
    
            public ICommand EditTodo
            {
                get
                {
                    if (this.editTodo == null)
                    {
                        this.editTodo = new RelayCommand(this.OnEditTodo);
                    }
    
                    return this.editTodo;
                }
            }
    
            public ICommand DeleteTodo
            {
                get
                {
                    if (this.deleteTodo == null)
                    {
                        this.deleteTodo = new RelayCommand(this.OnDeleteTodo);
                    }
    
                    return this.deleteTodo;
                }
            }
    
            public void OnEditTodo(object parameter)
            {
                // perform edit here
                var todo = parameter as TodoModel;
            }
    
            public void OnDeleteTodo(object parameter)
            {
                // perform delete here
                var todo = parameter as TodoModel;
            }
        }
    }
