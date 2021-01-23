    public class ProjectInfo : IProjectInfo
    {
        public string ProjectName { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectAuthor { get; set; }
        public string ProjectCopyright { get; set; }
        public string ProjectTrademark { get; set; }
        public string ProjectCreationDate { get; set; }
        public string ProjectVersion { get; set; }
        public string ProjectFileName { get; private set; }
        public string ProjectFilePath { get; private set; }
        public string FullProjectPath { get; private set; }
        public ProjectInfo(IProjectInfo src)
        {
            this.ProjectName = src.ProjectName;
            this.ProjectTitle = src.ProjectTitle;
            this.ProjectDescription = src.ProjectDescription;
            this.ProjectAuthor = src.ProjectAuthor;
            this.ProjectCopyright = src.ProjectCopyright;
            this.ProjectTrademark = src.ProjectTrademark;
            this.ProjectCreationDate = src.ProjectCreationDate;
            this.ProjectVersion = src.ProjectVersion;
            this.ProjectFileName = src.ProjectFileName;
            this.ProjectFilePath = src.ProjectFilePath;
            this.FullProjectPath = src.FullProjectPath;
        }
    }
