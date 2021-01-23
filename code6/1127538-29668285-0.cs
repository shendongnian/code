    using System.Management;
     
    public partial class Win_Win32_VideoController : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_VideoController");
     
            foreach (ManagementObject obj in objvide.Get())
            {
                Response.Write("Name  -  " + obj["Name"] + "</br>");
                Response.Write("DeviceID  -  " + obj["DeviceID"] + "</br>");
                Response.Write("AdapterRAM  -  " + obj["AdapterRAM"] + "</br>");
                Response.Write("AdapterDACType  -  " + obj["AdapterDACType"] + "</br>");
                Response.Write("Monochrome  -  " + obj["Monochrome"] + "</br>");
                Response.Write("InstalledDisplayDrivers  -  " + obj["InstalledDisplayDrivers"] + "</br>");
                Response.Write("DriverVersion  -  " + obj["DriverVersion"] + "</br>");
                Response.Write("VideoProcessor  -  " + obj["VideoProcessor"] + "</br>");
                Response.Write("VideoArchitecture  -  " + obj["VideoArchitecture"] + "</br>");
                Response.Write("VideoMemoryType  -  " + obj["VideoMemoryType"] + "</br>");
            }
        }
    }
