    public MainWindow()
    {
      ...
      PreviewClosed += OnPreviewClosed;
    }
    private void OnPreviewClosed(object sender, WindowPreviewClosedEventArgs e)
            {
                m_savedState = WindowState;
                Hide();
                e.Cancel = true;
            }
