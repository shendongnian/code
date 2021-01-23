    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    namespace SimpleViewModel
    {
        public partial class ResultForm : Form
        {
            protected ViewModel viewModel;
            public ViewModel ViewModel
            {
                get
                {
                    return viewModel;
                }
                set
                {
                    if (object.Equals(ViewModel, value))
                    {
                        return;
                    }
                    if (ViewModel != null)
                    {
                        viewModel.PropertyChanged -= OnViewModelChanged;
                    }
                    viewModel = value;
                    if (ViewModel != null)
                    {
                        viewModel.PropertyChanged += OnViewModelChanged;
                    }
                }
            }
            protected virtual void OnViewModelChanged(object sender, PropertyChangedEventArgs e)
            {
                var vm = sender as ViewModel;
                if (vm == null)
                {
                    return;
                }
                if (e.PropertyName == "Result")
                {
                    lblResult.Text = vm.Result;
                }
            }
            public ResultForm()
            {
                InitializeComponent();
            }
            public ResultForm(ViewModel viewModel)
            {
                InitializeComponent();
                ViewModel = viewModel;
            }
            protected override void OnClosed(EventArgs e)
            {
                ViewModel = null;
                base.OnClosed(e);
            }
        }
    }
