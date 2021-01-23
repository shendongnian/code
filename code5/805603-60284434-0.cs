csharp
async Task<double> GetCpuLoadAsync(TimeSpan MeasurementWindow)
{
 	Process CurrentProcess = Process.GetCurrentProcess();
	TimeSpan StartCpuTime = CurrentProcess.TotalProcessorTime;
	Stopwatch Timer = Stopwatch.StartNew();
	await Task.Delay(MeasurementWindow);
	TimeSpan EndCpuTime = CurrentProcess.TotalProcessorTime;
	Timer.Stop();
	return (EndCpuTime - StartCpuTime).TotalMilliseconds / (Environment.ProcessorCount * Timer.ElapsedMilliseconds);
}
Use the following code to call the function and replace the TimeSpan with the window to monitor:
csharp
double CpuLoad = await GetCpuLoadAsync(TimeSpan.FromSeconds(10));
