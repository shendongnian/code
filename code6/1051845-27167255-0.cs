	for (int p1 = 1; p1 < netmask[0]; p1++) {
		for (int p2 = 1; p2 < netmask[1]; p2++) {
			for (int p3 = 1; p3 < netmask[2]; p3++) {
				for (int p4 = 1; p4 < netmask[3]; p4++) {
					var ip = new IPAdress(p1, p2, p3, p4);
					if (trytoreach(ip)) {
						return ip;
					}
				}
			}
		}
	}
