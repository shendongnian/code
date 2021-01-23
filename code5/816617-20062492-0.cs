	Imports System.Windows.Forms
	Imports System.Runtime.InteropServices
	Module Module1
		Private counter As Integer = 0
		Private WithEvents IM As InterceptMouse
		Sub Main()
			IM = InterceptMouse.Instance
			IM.Start()
			While counter < 3
				System.Threading.Thread.Sleep(100)
			End While
			IM.Shutdown()
			Console.Write("Press Enter to Quit")
			Console.ReadLine()
		End Sub
		Private Sub IM_MouseClick(pt As InterceptMouse.POINT) Handles IM.MouseClick
			Console.WriteLine(pt.x.ToString() & ", " & pt.y.ToString())
			counter = counter + 1
		End Sub
		Public Class InterceptMouse
			Inherits ApplicationContext
			Public Event MouseClick(ByVal pt As InterceptMouse.POINT)
			Private Shared _IM As InterceptMouse
			Public Shared ReadOnly Property Instance() As InterceptMouse
				Get
					If IsNothing(_IM) Then
						_IM = New InterceptMouse()
					End If
					Return _IM
				End Get
			End Property
			Private _proc As LowLevelMouseProc = AddressOf HookCallback
			Private _hookID As IntPtr = IntPtr.Zero
			Private T As System.Threading.Thread = Nothing
			Private Sub New()
			End Sub
			Public Sub Start()
				If IsNothing(T) Then
					T = New Threading.Thread(AddressOf Main)
					T.Start()
				End If
			End Sub
			Private Sub Main()
				_hookID = SetHook(_proc)
				Application.Run(Me)
				UnhookWindowsHookEx(_hookID)
				T = Nothing
			End Sub
			Public Sub Shutdown()
				If Not IsNothing(T) Then
					Application.Exit()
				End If
			End Sub
			Private Function SetHook(proc As LowLevelMouseProc) As IntPtr
				Using curProcess As Process = Process.GetCurrentProcess()
					Using curModule As ProcessModule = curProcess.MainModule
						Return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0)
					End Using
				End Using
			End Function
			Private Delegate Function LowLevelMouseProc(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
			Private Function HookCallback(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
				Dim MouseSetting As Integer = MouseMessages.WM_LBUTTONDOWN
				Dim hookStruct As MSLLHOOKSTRUCT
				If nCode >= 0 AndAlso MouseSetting = CType(wParam, MouseMessages) Then
					hookStruct = CType(Marshal.PtrToStructure(lParam, GetType(MSLLHOOKSTRUCT)), MSLLHOOKSTRUCT)
					Dim pt As New POINT
					pt.x = hookStruct.pt.x
					pt.y = hookStruct.pt.y
					RaiseEvent MouseClick(pt)
				End If
				Return CallNextHookEx(_hookID, nCode, wParam, lParam)
			End Function
			Private Const WH_MOUSE_LL As Integer = 14
			Private Enum MouseMessages
				WM_LBUTTONDOWN = &H201
				WM_LBUTTONUP = &H202
				WM_MOUSEMOVE = &H200
				WM_MOUSEWHEEL = &H20A
				WM_RBUTTONDOWN = &H204
				WM_RBUTTONUP = &H205
			End Enum
			<StructLayout(LayoutKind.Sequential)> _
			Public Structure POINT
				Public x As Integer
				Public y As Integer
			End Structure
			<StructLayout(LayoutKind.Sequential)> _
			Private Structure MSLLHOOKSTRUCT
				Public pt As POINT
				Public mouseData As UInteger
				Public flags As UInteger
				Public time As UInteger
				Public dwExtraInfo As IntPtr
			End Structure
			<DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
			Private Shared Function SetWindowsHookEx(idHook As Integer, lpfn As LowLevelMouseProc, hMod As IntPtr, dwThreadId As UInteger) As IntPtr
			End Function
			<DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
			Public Shared Function UnhookWindowsHookEx(hhk As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
			End Function
			<DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
			Private Shared Function CallNextHookEx(hhk As IntPtr, nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
			End Function
			<DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
			Private Shared Function GetModuleHandle(lpModuleName As String) As IntPtr
			End Function
		End Class
	End Module
