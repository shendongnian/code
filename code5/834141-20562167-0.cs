    public enum DeploymentType { WinForms, WinServices, Azure }
    
    public interface IWhatDeploymentAmIUsing {
    	DeploymentType DeploymentType { get; }
    }
