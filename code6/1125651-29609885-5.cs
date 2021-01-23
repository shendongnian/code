    class ClientesViewModel
    {
        bool DeleteConfirmVisible;
        void ShowDeleteConfirm();
        ModalViewModel ModalDelete;
    }
    
    public class ModalViewModel
    {
        ICommand ConfirmDelete;
        ICommand TryClose;
    }
