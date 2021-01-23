    public partial class MainWindow : Window
    {
        //Declare background workers
        BackgroundWorker bwLoadCSV = new BackgroundWorker();
        ProgressDialog progressDialog;
    new ThreadStart(() =>
    {
        progressDialog = new ProgressDialog();
    private void bwLoadCSV_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        progressDialog.Close();
