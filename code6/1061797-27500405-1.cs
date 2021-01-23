    System.Net.IPAddress[] TempAd = Tempaddr.AddressList;
					foreach(IPAddress TempA in TempAd)
					{
						Ipaddr[1] = TempA.ToString();
						byte[] ab = new byte[6];
						int len = ab.Length;
						// This Function Used to Get The Physical Address
						int r = SendARP( (int) TempA.Address, 0, ab, ref len );
						string mac = BitConverter.ToString( ab, 0, 6 );
						Ipaddr[2] = mac;
					}			
