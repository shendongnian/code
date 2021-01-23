try
{
	
foreach
(Process proc in Process.GetProcessesByName("processname"))
{
proc.Kill();
}
}
catch(Exception ex)
{
	
}
