    // In your shared project
    namespace Company {
        public interface IDiagnosticWindow {
            void ShowMessage(string message);
        }
        public static class Utilities {
            private static IDiagnosticWindow _diagnosticWindow;
            public static void InitializeDiagnosticWindow(IDiagnosticWindow dw) {
                _diagnosticWindow = dw;
            }
            public static void ShowMessage(string message) {
                _diagnosticWindow.ShowMessage(message);
            }
        }
    }
    // In your WinForms project
    namespace Company.WinForms {
        public class WinFormsDiagnosticWindow : IDiagnosticWindow {
            public void ShowMessage(string message) {
                MessageBox.Show(message);
            }
        }
        static void Main() {
            Utilities.InitializeDiagnosticWindow(new WinFormsDiagnosticWindow());
        }
    }
