    public void Execute(object param)
    {
        m_viewModel.PerformSearch();
    }
    public interface IViewModel
    {
         void PerformSearch();
    }
