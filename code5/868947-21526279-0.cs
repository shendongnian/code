     string input = "Web.WebClient.Areas.Scada.Services.IScadaManualOverrideService,Web.WebClient.TDMSWebApp";
     int commaIndex = input.IndexOf(',');
     string remainder = input.Substring(0, commaIndex);
     int dotIndex = remainder.LastIndexOf('.');
     string output = remainder.Substring(dotIndex + 1);
