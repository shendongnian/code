                proc.Start();
                //het resultaat bekijken
                proc.WaitForExit();
                switch (proc.ExitCode)
                {
                    case 0: //connection succeeded
                        MessageBox.Show("Je bent geconnecteerd met de VPN");
                        isConnectedVPN = true;
                        btnConnectToVPN.Text = "Stop VPN";
                        break;
                    case 691: //wrong credentials
                        MessageBox.Show("De username en/of het wachtwoord kloppen niet.");
                        break;
                    case 623: // The VPN doesn't excist
                        MessageBox.Show("Deze VPN staat niet tussen de bestaande VPN's.");
                        break;
                    case 868: //the IP or domainname can't be found
                        MessageBox.Show("Het ip-adres of de domeinnaam kan niet gevonden worden");
                        break;
                    default: //other faults
                        MessageBox.Show("fout " + proc.ExitCode.ToString());
                        break;
                }
