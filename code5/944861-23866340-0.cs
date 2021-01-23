	<#@ template language="C#" #>
	<#@ output extension=".cs" #>
	<#@ assembly name="System.Management" #>
	<#@ assembly name="System.Core" #>
	<#@ import namespace="System.Management" #>
	<#@ import namespace="System.Collections.Generic" #>
	<#@ import namespace="System.Linq" #>
	using System.Net;
	public static class SelfIpAddress
	{
		public static readonly IPAddress dbgHostAddress = new IPAddress( new byte[ 4 ] { <#= String.Join( ", ", address ) #> } );
	}<#+
		static IEnumerable<ManagementObject> searchWmi( string q )
		{
			var mos = new ManagementObjectSearcher( q );
			return mos.Get().Cast<ManagementObject>();
		}
		static byte[] findTheAddress()
		{
			string q1 = @"SELECT * FROM Win32_NetworkAdapter where ServiceName='VMSMP' and NetConnectionID is not NULL";
			ManagementObject adapter = searchWmi( q1 ).Where( mo => mo[ "NetConnectionID" ].ToString().Contains( "Emulator Internal Switch" ) ).FirstOrDefault();
			if( null == adapter )
				throw new Exception( "Network adapter was not found" );
			int interfaceIndex = int.Parse( adapter[ "InterfaceIndex" ].ToString() );
			string q2 = @"SELECT * FROM Win32_NetworkAdapterConfiguration where InterfaceIndex = " + interfaceIndex.ToString();
			ManagementObject adapterConfig = searchWmi( q2 ).FirstOrDefault();
			string address = ( adapterConfig[ "IPAddress" ] as string[] ).FirstOrDefault();
			if( null == address )
				throw new Exception( "Network adapter has no address" );
			return address.Split( '.' ).Select( c => byte.Parse( c ) ).ToArray();
		}
		readonly byte[] address = findTheAddress();
	#>
