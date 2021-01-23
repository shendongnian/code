      if (disk == null && hdd == null && nic == null && ram == null)
      {
          postData = "user=" + SystemInformation.ComputerName; // user = a string containing the hostname
      }
      else
      {
          postData = "user=" + SystemInformation.ComputerName + "&disk=" + disk + "&hdd=" + hdd + "&nic=" + nic + "&ram" + ram;
      }
