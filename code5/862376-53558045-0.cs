			using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using System.Threading.Tasks;
			using System.Runtime.InteropServices;
			namespace Apteka.Printer
			{
				public class RawPrinterHelper
				{
					[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
					public class DOCINFOA
					{
						[MarshalAs(UnmanagedType.LPStr)]
						public string pDocName;
						[MarshalAs(UnmanagedType.LPStr)]
						public string pOutputFile;
						[MarshalAs(UnmanagedType.LPStr)]
						public string pDataType;
					}
					[DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
					public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, ref IntPtr hPrinter, IntPtr pd);
					[DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
					public static extern bool ClosePrinter(IntPtr hPrinter);
					[DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
					public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In()][MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);
					[DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
					public static extern bool EndDocPrinter(IntPtr hPrinter);
					[DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
					public static extern bool StartPagePrinter(IntPtr hPrinter);
					[DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
					public static extern bool EndPagePrinter(IntPtr hPrinter);
					[DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
					public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, ref Int32 dwWritten);
					private IntPtr hPrinter = new IntPtr(0);
					private DOCINFOA di = new DOCINFOA();
					private bool PrinterOpen = false;
					public bool PrinterIsOpen
					{
						get
						{
							return PrinterOpen;
						}
					}
					public bool OpenPrint(string szPrinterName)
					{
						if (PrinterOpen == false)
						{
							di.pDocName = ".NET RAW Document";
							di.pDataType = "RAW";
							if (OpenPrinter(szPrinterName.Normalize(), ref hPrinter, IntPtr.Zero))
							{
								if (StartDocPrinter(hPrinter, 1, di))
								{
									if (StartPagePrinter(hPrinter))
										PrinterOpen = true;
								}
							}
						}
					   return PrinterOpen;
					}
					public void ClosePrint()
					{
						if (PrinterOpen)
						{
							EndPagePrinter(hPrinter);
							EndDocPrinter(hPrinter);
							ClosePrinter(hPrinter);
							PrinterOpen = false;
						}
					}
					public bool SendStringToPrinter(string szPrinterName, string szString)
					{
						if (PrinterOpen)
						{
							IntPtr pBytes;
							Int32 dwCount;
							Int32 dwWritten = 0;
							dwCount = szString.Length;
							pBytes = Marshal.StringToCoTaskMemAnsi(szString);
							var res= WritePrinter(hPrinter, pBytes, dwCount, ref dwWritten);
							Marshal.FreeCoTaskMem(pBytes);
							return res;
						}
						else
							return false;
					}
				}
			}
