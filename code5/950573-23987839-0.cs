        public ObservableCollection<Project> Projects
        {
            get { return (ObservableCollection<Project>)GetValue(ProjectsProperty); }
            set { SetValue(ProjectsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Projects.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectsProperty =
            DependencyProperty.Register("Projects", typeof(ObservableCollection<Project>), typeof(ViewModel), new PropertyMetadata(null));
        public ObservableCollection<Language> Languages
        {
            get { return (ObservableCollection<Language>)GetValue(LanguagesProperty); }
            set { SetValue(LanguagesProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Languages.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LanguagesProperty =
            DependencyProperty.Register("Languages", typeof(ObservableCollection<Language>), typeof(ViewModel), new PropertyMetadata(null));
        public Project SelectedProject
        {
            get { return (Project)GetValue(SelectedProjectProperty); }
            set { SetValue(SelectedProjectProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SelectedProject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectProperty =
            DependencyProperty.Register("SelectedProject", typeof(Project), typeof(ViewModel), new PropertyMetadata(null, OnSelectedProjectChanged));
        public Language SelectedLanguage
        {
            get { return (Language)GetValue(SelectedLanguageProperty); }
            set { SetValue(SelectedLanguageProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SelectedLanguage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedLanguageProperty =
            DependencyProperty.Register("SelectedLanguage", typeof(Language), typeof(ViewModel), new PropertyMetadata(null));
