+--------------------------------------------+--------------------------------------------+
|               <b>WebClient</b>                    |               <b>HttpClient</b>                   |
+--------------------------------------------+--------------------------------------------+
| Available in older versions of .NET        | .NET 4.5 only.  Created to support the     |
|                                            | growing need of the Web API REST calls     |
+--------------------------------------------+--------------------------------------------+
| WinRT applications cannot use WebClient    | HTTPClient can be used with WinRT          |
+--------------------------------------------+--------------------------------------------+
| Provides progress reporting for downloads  | No progress reporting for downloads        |
+--------------------------------------------+--------------------------------------------+
| Does not reuse resolved DNS,               | Can reuse resolved DNS, cookie             |
| configured cookies                         | configuration and other authentication     |
+--------------------------------------------+--------------------------------------------+
| You need to new up a WebClient to          | Single HttpClient can make concurrent      |
| make concurrent requests.                  | requests                                   |
+--------------------------------------------+--------------------------------------------+
| Thin layer over WebRequest and             | Thin layer of HttpWebRequest and           |
| WebResponse                                | HttpWebResponse                            |
+--------------------------------------------+--------------------------------------------+
| Mocking and testing WebClient is difficult | Mocking and testing HttpClient is easy     |
+--------------------------------------------+--------------------------------------------+
| Supports FTP                               | No support for FTP                         |
+--------------------------------------------+--------------------------------------------+
| Both Synchronous and Asynchronous methods  | All IO bound methods in                    |
| are available for IO bound requests        | HTTPClient are asynchronous                |
+--------------------------------------------+--------------------------------------------+
