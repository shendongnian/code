And in the code behind, in the constructor of my Window
public DocumentPropertyListViewModel DocumentPropertyListViewModel { get; set; }
public FilePropertiesViewModel(){
   this.DocumentPropertyListViewModel = new DocumentPropertyListViewModel(File.Properties, false);
}
Still troubled by the statement above with the code fragment that you provided saying you had it in the codebehind, did you mean ViewModel?
Also what container are you using for IoC: MEF, SimpleContainer, etc...? Nothing?
